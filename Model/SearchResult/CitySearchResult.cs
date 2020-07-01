using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SearchResult
{
    public class CitySearchResult :BaseSearchResult
    {
        public List<CityDTO> cityDTOs { get; set; }
    }
}
