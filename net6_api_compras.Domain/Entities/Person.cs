﻿using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Domain.Entities
{
    // Sealed não pode ser herdada
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id da pessoa deve ser maior que zero!");

            Id = id;

            Validate(name, document, phone);
            Purchases = new List<Purchase>();
        }
        public Person(string name, string document, string phone)
        {
            Validate(name, document, phone);
            Purchases = new List<Purchase>();
        }

        public void Validate(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone deve ser informado!");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
