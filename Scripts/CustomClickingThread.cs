﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class CustomClickingThread {
        MouseEventData mouseClickHandler = new MouseEventData();
        
        public float LeftClickSpeed { get; internal set; }
        public float RightClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public float RandomizationAmount { get; internal set; }
        public List<ClickPosition> ClickPositions { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    foreach(ClickPosition click in ClickPositions) {
                        if (click.GetMouseClickType() == MouseButtons.Left) {
                            Thread.Sleep((int) (mouseClickHandler.GetRandomizedClickSpeed(Randomize, LeftClickSpeed, RandomizationAmount) * 1000));
                        } else {
                            Thread.Sleep((int) (mouseClickHandler.GetRandomizedClickSpeed(Randomize, RightClickSpeed, RandomizationAmount) * 1000));
                        }
                        mouseClickHandler.ClickCustomPositionEvent(click.GetX(), click.GetY(), click.GetMouseClickType());
                    }
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}