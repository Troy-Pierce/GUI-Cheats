using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Threading;

namespace Blueberry.Forms
{
    class KeyBoardHook
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(KeyBoardHook vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        // Numpad 7 = 103 (open/close)
        // Numpad 8 = 104 (Up)
        // Numpad 9 = 105 (Exit)
        // Numpad 4 = 100 (Backpage)
        // Numpad 5 = 101 (Down)
        // Numpad 6 = 102 (Select)
        
        public KeyBoardHook(Menu menu)
        {
            Thread thread = new Thread(() =>
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Elapsed += OnTick;
                timer.Enabled = true;
                void OnTick(object sender, ElapsedEventArgs e)
                {
                    timer.Enabled = false;
                    timer.Stop();
                }
                void StartTimer()
                {
                    timer.Enabled = true;
                    timer.Interval = 110;
                    timer.Start();
                }
                while (menu.isRunning())
                {
                    if (!timer.Enabled)
                    {
                        if (GetAsyncKeyState(103) == -32768)
                        {
                            if (menu.isOpen())
                            {
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.CloseMenu));
                            }
                            else
                            {
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.OpenMenu));
                            }
                            StartTimer();
                        }
                        if (menu.isOpen())
                        {
                            if (GetAsyncKeyState(105) == -32768)
                            {
                                StartTimer();
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.ExitMenu));
                            }
                            else if (GetAsyncKeyState(104) == -32768)
                            {
                                StartTimer();
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.GetCurrentPage().PreviousButton));
                            }
                            else if (GetAsyncKeyState(101) == -32768)
                            {
                                StartTimer();
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.GetCurrentPage().NextButton));
                            }
                            else if (GetAsyncKeyState(100) == -32768)
                            {
                                StartTimer();
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.BackPage));
                            }
                            else if (GetAsyncKeyState(102) == -32768)
                            {
                                StartTimer();
                                menu.dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(menu.GetCurrentPage().GetCurrentButton().Activate));
                            }
                        }
                    }
                }
            });
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        
    }
}
