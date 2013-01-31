/* ========================================
 *
 * Copyright YOUR COMPANY, THE YEAR
 * All Rights Reserved
 * UNPUBLISHED, LICENSED SOFTWARE.
 *
 * CONFIDENTIAL AND PROPRIETARY INFORMATION
 * WHICH IS THE PROPERTY OF your company.
 *
 * ========================================
*/
#include <device.h>
#include <stdlib.h>

#define GET_CELL(grid, x, y) (((grid)[(x)*6+(y)/8] >> ((y) & 0x7)) & 1)
#define SET_CELL(grid, x, y) (grid)[(x)*6+(y)/8] |= 1 << ((y) & 0x7)
#define CLEAR_CELL(grid, x, y) (grid)[(x)*6+(y)/8] &= ~(1 << ((y) & 0x7))

#define WIDTH 84
#define HEIGHT 48
#define MUTATION_RATE 2663050

int count_live(uint8 *grid, int x, int y) {
    int dx, dy, ret=0;
    for(dx = -1; dx < 2; dx++) {
        for(dy = -1; dy < 2; dy++) {
            if(dx == 0 && dy == 0) continue;
            ret += GET_CELL(grid, (x + dx + WIDTH) % WIDTH, (y + dy + HEIGHT) % HEIGHT);
        }
    }
    return ret;
}

void main()
{
    LCD_1_buffer buf1, buf2;
    LCD_1_buffer *current=&buf1, *next=&buf2, *tmp;
    int seed;
    int x, y, i, num;
    
    PrISM_1_Start();
    LCD_1_Start();
    CySetTemp();

    /* Read in the seed value */
    seed = CY_GET_REG32(CYDEV_EE_BASE);
    srand(seed);

    CyGlobalIntEnable; /* Uncomment this line to enable global interrupts. */

    // Initialize the board with random data
    for(i = 0; i < 504; i++)
        current->data[i] = (uint8)rand();
    
    // Write out a new seed
    seed = rand();
    EEPROM_1_Write(&seed, 0);
    
    for(;;)
    {
        for(x = 0; x < 84; x++) {
            for(y = 0; y < 48; y++) {
                if(rand() < MUTATION_RATE) {
                    SET_CELL(next->data, x, y);
                    continue;
                }
                num = count_live(current->data, x, y);
                if(num < 2 || num > 3) {
                    CLEAR_CELL(next->data, x, y);
                } else if(GET_CELL(current->data, x, y) || num == 3) {
                    SET_CELL(next->data, x, y);
                } else {
                    CLEAR_CELL(next->data, x, y);
                }
            }
        }
        tmp = next;
        next = current;
        current = tmp;
        
        LCD_1_Update(current);
    }
}

/* [] END OF FILE */
