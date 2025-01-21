using System;
using System.Collections.ObjectModel;

namespace ListPerformanceIssue;

public class MyListPageViewModel
    {
        public ObservableCollection<MyItem> Items { get; set; }

        public MyListPageViewModel()
        {
            // Sample data
            Items = new ObservableCollection<MyItem>();

            for (int i = 0; i < 400; i++)
            {
                Items.Add(
                    new MyItem {
                        Text1 = $"Text1 {i}", 
                        Text2 = $"Text2 {i}",
                        Text3 = $"Text3 {i}", 
                        Text4 = $"Text4 {i}",
                        Text5 = $"Text5 {i}",
                        AText = $"AText {i}",
                        ANumber = i,
                        AColor = Colors.HotPink,

                        BText = $"BText {i}",
                        BColor = Colors.Blue,
                        CColor = Colors.White,
                    } 
                );
            }
            
        }
    }

    public class MyItem
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }

        public string AText { get; set; }
        public int ANumber { get; set; }

        public Color AColor { get; set; }

        public Color BColor { get; set; }
        public Color CColor { get; set; }
        public string BText { get; set; }

        
    }
