using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    //省略自动生成
    public class FoodItem
    {
        public int FoodID{get;set;}//菜品ID
        public string FoodName { get; set; }//菜品名称
        public int ClickCount{ get; set; }//销量
        public string StyleName { get; set; }//菜系名称，来自FoodStyle表
        public float Price { get; set; }//价格
        public string ImagePath { get; set; }//图片
        public string IsHot { get; set; }
    }
}
