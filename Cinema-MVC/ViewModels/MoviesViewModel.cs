using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;
using Cinema_MVC.Dtos;

namespace Cinema_MVC.ViewModels
{
    public class MoviesViewModel
    {
        public List<MovieDto> Movies { get; set; }
    }
}