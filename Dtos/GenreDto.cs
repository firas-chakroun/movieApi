﻿using System.ComponentModel.DataAnnotations;

namespace movieApi.Dtos
{
    public class GenreDto
    {

        [MaxLength(100)]
        public string Name
        {
            get; set;
        }
    }
}

