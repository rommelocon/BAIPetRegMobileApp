﻿namespace BAIPetRegMobileApp.Models.PetRegistration
{
    public class PaginatedResponse<T>
    {
        public int? TotalRecords { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public List<T>? Data { get; set; }
    }
}
