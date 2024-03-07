using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.ViewModels
{
    public class IssueViewModel: FreshBasePageModel
    {
		private int issueNumber;

		public int IssueNumber
		{
			get { return issueNumber; }
			set { issueNumber = value; RaisePropertyChanged(nameof(IssueNumber)); }
		}

		public IssueViewModel()
		{
			//this.IssueNumber = issueNumber;
		}

        public override void Init(object initData)
        {
            base.Init(initData);

			this.IssueNumber = Convert.ToInt32(initData);
        }

    }
}
