﻿using System;

namespace DeltaTre.Application.GetContact
{
    public class GetContactQueryResponse
    {
        public Guid ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}