using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PRN
{
    public class SpeakText
    {
        private WebBrowser webBrowser;
        public WebBrowser WebBrowser
        {
            get { return webBrowser; }
            set { webBrowser = value; }
        }
        public SpeakText(WebBrowser wb)
        {
            this.WebBrowser = wb;
        }

        private void SetText(string data)
        {
            HtmlElement element = WebBrowser.Document.GetElementById("text");
            element.SetAttribute("value", data);
        }
        private void Speak()
        {
            HtmlElement element = WebBrowser.Document.GetElementById("playbutton");
            element.InvokeMember("click");

        }
        public void Spreak(string data)
        {
            SetText(data);
            Speak();
        }
    }
}
