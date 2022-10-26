﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Passenger.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Address
    {
        [Required]
        [StringLength(9)]
        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        [StringLength(100)]
        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [StringLength(30)]
        public string Complement { get; set; }

        [StringLength(30)]
        [JsonProperty("bairro")]
        public string District { get; set; }

        [StringLength(30)]
        [JsonProperty("localidade")]
        public string City { get; set; }

        [StringLength(25)]
        [JsonProperty("uf")]
        public string State { get; set; }
        public int Number { get; set; }

    }
}
