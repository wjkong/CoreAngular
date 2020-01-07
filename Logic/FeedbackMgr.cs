using Konger.CoreAngular.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Konger.CoreAngular.Logic
{
    public interface IFeedbackMgr 
    {
        bool Add();
    }
    public class FeedbackMgr : Feedback, IFeedbackMgr
    {
        public bool Add()
        {
            throw new NotImplementedException();
        }
    }
}
