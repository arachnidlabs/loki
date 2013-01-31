/*******************************************************************************
 * File Name: `$INSTANCE_NAME`.h
 * Version `$CY_MAJOR_VERSION`.`$CY_MINOR_VERSION`
 *
 *  Description:
 *    Provides an interface to 'Nokia 5110' type LCD screens, or anything else
 *    driven by the PCD8544 LCD controller.
 *
 *******************************************************************************
 *
 * Copyright Arachnid Labs, 2013
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this
 * list of conditions and the following disclaimer.
 * 
 * Redistributions in binary form must reproduce the above copyright notice,
 * this list of conditions and the following disclaimer in the documentation
 * and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *******************************************************************************/

#include "`$INSTANCE_NAME`_lcd.h"
#include "device.h"

#define MODE_BASIC 0x00
#define MODE_EXTENDED 0x01

#define STATE_CONTROL 0x00
#define STATE_DATA 0x02

uint8 `$INSTANCE_NAME`_initVar = 0;
uint8 current_mode = MODE_BASIC;
uint8 transmit_dma, buffer_td, interrupt_td, do_nothing;

void set_state(uint8 state) {
    uint8 current_state = `$INSTANCE_NAME``[LCD_Control]`Read();
    if((current_state & 0x02) != state) {
        while(`$INSTANCE_NAME`_Busy());
        if(state == STATE_DATA) {
            `$INSTANCE_NAME``[LCD_Control]`Write(current_state | STATE_DATA);
        } else {
            `$INSTANCE_NAME``[LCD_Control]`Write(current_state & ~STATE_DATA);
        }
    }
}

void set_mode(uint8 mode) {
    set_state(STATE_CONTROL);
    if(current_mode != mode) {
        `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x20 | mode);
        current_mode = mode;
    }
}

void `$INSTANCE_NAME`_Start(void) {
    if(`$INSTANCE_NAME`_initVar == 0) {
        `$INSTANCE_NAME`_Init();
        `$INSTANCE_NAME`_Enable();
        `$INSTANCE_NAME`_initVar = 1;
    }
}

void `$INSTANCE_NAME`_Init(void) {
    `$INSTANCE_NAME``[LCD_SPI]`Init();
    
    transmit_dma = `$INSTANCE_NAME``[LCD_DMA]`DmaInitialize(
        1 /* burstCount */,
        1 /* requestPerBurst */,
        HI16(CYDEV_SRAM_BASE) /* upperSrcAddress */,
        HI16(CYDEV_PERIPH_BASE) /* upperDestAddress */);
    buffer_td = CyDmaTdAllocate();
    interrupt_td = CyDmaTdAllocate();

    CyDmaTdSetConfiguration(buffer_td, sizeof(`$INSTANCE_NAME`_buffer), interrupt_td, TD_INC_SRC_ADR);
    CyDmaTdSetConfiguration(interrupt_td, 1, interrupt_td, 0);
    
    CyDmaTdSetAddress(interrupt_td, LO16((uint32)&do_nothing), LO16((uint32)&do_nothing));
}

void `$INSTANCE_NAME`_Enable(void) {
    // Take display out of reset
    `$INSTANCE_NAME``[LCD_Control]`Write(0x01);

    // Enable the SPI interface
    `$INSTANCE_NAME``[LCD_SPI]`Enable();

    // Default display settings
    `$INSTANCE_NAME`_SetVop(0x60);
    `$INSTANCE_NAME`_SetTemperatureCoefficient(0x00);
    `$INSTANCE_NAME`_SetBiasSystem(0x04);
    current_mode = MODE_BASIC;
    `$INSTANCE_NAME`_SetAddressMode(`$INSTANCE_NAME`_ADDR_VERTICAL);
    `$INSTANCE_NAME`_SetDisplayMode(`$INSTANCE_NAME`_DISPLAY_NORMAL);
}

void `$INSTANCE_NAME`_SetAddressMode(int addrmode) {
    set_state(STATE_CONTROL);
    `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x20 | current_mode | addrmode);
}

void `$INSTANCE_NAME`_SetDisplayMode(int displaymode) {
    set_mode(MODE_BASIC);
    `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x08 | displaymode);
}

void `$INSTANCE_NAME`_SetTemperatureCoefficient(int tc) {
    set_mode(MODE_EXTENDED);
    `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x04 | tc);
}

void `$INSTANCE_NAME`_SetBiasSystem(int bias) {
    set_mode(MODE_EXTENDED);
    `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x10 | bias);
}

void `$INSTANCE_NAME`_SetVop(int vop) {
    set_mode(MODE_EXTENDED);
    `$INSTANCE_NAME``[LCD_SPI]`WriteTxData(0x80 | vop);
}

void `$INSTANCE_NAME`_Update(`$INSTANCE_NAME`_buffer *buffer) {
    // If we're transferring something, wait until it's done.
    while(`$INSTANCE_NAME`_Busy());
    
    // Switch to data mode
    set_state(STATE_DATA);
    
    // Copy from the provided buffer to the SPI output buffer
    CyDmaTdSetAddress(buffer_td, LO16((uint32)buffer->data), LO16((uint32)`$INSTANCE_NAME``[LCD_SPI]`BSPIM_sR8_Dp_u0__F0_REG));
    
    // Enable and reset the DMA
    CyDmaChSetInitialTd(transmit_dma, buffer_td);
    CyDmaChEnable(transmit_dma, 1);
    CyDmaChSetRequest(transmit_dma, CPU_REQ);
}

int `$INSTANCE_NAME`_Busy(void) {
    return !(`$INSTANCE_NAME``[LCD_SPI]`ReadTxStatus() & (`$INSTANCE_NAME``[LCD_SPI]`STS_SPI_DONE | `$INSTANCE_NAME``[LCD_SPI]`STS_SPI_IDLE));
}

/* [] END OF FILE */
