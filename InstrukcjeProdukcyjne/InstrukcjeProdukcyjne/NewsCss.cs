using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    public class NewsCss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public Color BackgroundColor { get; set; }

    }

    public class NewsCssColection : List<NewsCss>
    {
        public NewsCssColection()
        {
            this.Add(new NewsCss {Id=0, Name = "", BackgroundColor = Color.FromArgb(255, 255, 128), Color = Color.Black });
            this.Add(new NewsCss { Id = 1, Name = "text-Green", BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#06B211"), Color = Color.Black }); //#06B211;
            this.Add(new NewsCss { Id = 2, Name = "text-Orange", BackgroundColor = Color.Orange, Color = Color.Black });
            this.Add(new NewsCss { Id = 3, Name = "text-Red", BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#BC0B0B"), Color = Color.LightGray }); //#BC0B0B
        }


        public NewsCss GetCss(int CssId)
        {
            var x = this.Find(m => m.Id == CssId);
            if (x == null)
                x = this[0];
            return x;
        }


        public NewsCss GetCss(string CssName)
        {
            var x = this.Find(m => m.Name == CssName);
            if (x == null)
                x = this[0];
            return x;
        }

    }
}
