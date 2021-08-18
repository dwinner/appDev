﻿using System;
using PropertyChanged;

namespace Chapter7.Accounts
{
    [ImplementPropertyChanged]
    public class AccountOverview
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}