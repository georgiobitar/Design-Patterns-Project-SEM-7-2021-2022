using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string ImageSource { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }

        //public string LastMessage
        //{
        //    get;

        //    set
        //    {
        //        if (Messages.Count == 0)
        //            LastMessage = "";

        //        else
        //            LastMessage = Messages.Last().Message;
        //    }
        
        //}
    }
}
