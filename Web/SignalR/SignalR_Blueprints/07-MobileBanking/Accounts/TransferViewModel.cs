﻿using System.Windows.Input;
using Bifrost.Interaction;
using Bifrost.Messaging;
using PropertyChanged;

namespace Chapter7.Accounts
{
    [ImplementPropertyChanged]
    public class TransferViewModel
    {
        IMessenger _messenger;
        IAccountsOverview _accountsOverview;
        public TransferViewModel(IMessenger messenger, IAccountsOverview accountsOverview)
        {
            _messenger = messenger;
            Amount = "0";
            messenger.SubscribeTo<TransferMessage>(t =>
            {
                From = t.AccountNumber;
                To = string.Empty;
                Amount = "0";
            });
            _accountsOverview = accountsOverview;

            TransferCommand = DelegateCommand.Create(Transfer);
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Amount { get; set; }

        public ICommand TransferCommand { get; private set; }
        public void Transfer()
        {
            decimal amount = 0;
            decimal.TryParse(Amount, out amount);
            _accountsOverview.Transfer(From, To, amount);

            _messenger.Publish(new NavigateHomeMessage());

            From = string.Empty;
            To = string.Empty;
            Amount = "0";
        }
    }
}
