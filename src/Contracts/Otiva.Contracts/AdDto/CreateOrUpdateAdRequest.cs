﻿using Otiva.Contracts.Attributs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Contracts.AdDto
{
    public class CreateOrUpdateAdRequest
    {
        [CheckCurseWord]
        public string Name { get; set; }

        [CheckCurseWord]
        public string Description { get; set; }

        public Guid SubcategoryId { get; set; }

        public decimal Price { get; set; }

        public string KodBase64 { get; set; }

        public bool PossibleOfDelivery { get; set; }

    }
}
