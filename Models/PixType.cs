﻿using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PixType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PixType()
        {
            
        }
        public PixType(PixTypeDTO DTO)
        {
            this.Name = DTO.DescriptionPix;
        }
    }
}
