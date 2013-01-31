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

#include "device.h"

#if !defined(PCD8544_`$INSTANCE_NAME`_H)
#define PCD8544_`$INSTANCE_NAME`_H

#define `$INSTANCE_NAME`_ADDR_VERTICAL 0x02
#define `$INSTANCE_NAME`_ADDR_HORIZONTAL 0x00

#define `$INSTANCE_NAME`_DISPLAY_BLANK 0x00
#define `$INSTANCE_NAME`_DISPLAY_NORMAL 0x04
#define `$INSTANCE_NAME`_DISPLAY_SOLID 0x01
#define `$INSTANCE_NAME`_DISPLAY_INVERSE 0x05

typedef struct `$INSTANCE_NAME`_buffer {
    uint8 data[504];
} `$INSTANCE_NAME`_buffer;

extern uint8 `$INSTANCE_NAME`_initVar;

extern void `$INSTANCE_NAME`_Start(void);
extern void `$INSTANCE_NAME`_Init(void);
extern void `$INSTANCE_NAME`_Enable(void);

extern void `$INSTANCE_NAME`_SetAddressMode(int);
extern void `$INSTANCE_NAME`_SetDisplayMode(int);
extern void `$INSTANCE_NAME`_SetTemperatureCoefficient(int);
extern void `$INSTANCE_NAME`_SetBiasSystem(int);
extern void `$INSTANCE_NAME`_SetVop(int);

extern void `$INSTANCE_NAME`_Update(`$INSTANCE_NAME`_buffer*);

extern int `$INSTANCE_NAME`_Busy(void);

#endif
//[] END OF FILE
