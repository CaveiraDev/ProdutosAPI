﻿using FluentValidation;
using ProdutosAPI.Validations.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProdutosAPI.Validations
{
    public abstract class ValidadorAbstratoCadastro<T> : ValidadorAbstrato<T>, IValidador<T>
        where T : class
    {
        public abstract void AssineRegrasInclusao();
        public abstract void AssineRegrasAtualizacao();
        public abstract void AssineRegrasExclusao();
    }
}