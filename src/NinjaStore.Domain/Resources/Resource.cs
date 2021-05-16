using NinjaStore.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace NinjaStore.Domain.Resources
{
    public enum Resource
    {
        // Client 
        [Description("Nome obrigátorio")]
        RequiredName,
        [Description("Email inválido")]
        InvalidEmail,
        [Description("Email obrigátorio")]
        RequiredEmail,
        // Address 
        [Description("Rua obrigátorio")]
        RequiredNameAddress,
        [Description("Cep obrigátorio")]
        RequiredCep,
        [Description("Bairro obrigátorio")]
        RequiredDistrict,
        [Description("Cidade obrigátorio")]
        RequiredCity,
        [Description("Estado obrigátorio")]
        RequiredState,
        [Description("Número obrigátorio")]
        RequiredNumber,
        // Product
        [Description("Descrição obrigátorio")]
        RequiredDescription,
        [Description("Valor obrigátorio")]
        RequiredValue,
        [Description("O valor deve ser maior que zero")]
        // Order
        ValueMustbeGreaterThanZero,
        [Description("Ordem sem cliente")]
        OrderWithoutCustomer,
        [Description("Nenhum produto no pedido")]
        NoProductsInOrder,
        [Description("Pedido sem data de compra")]
        RequiredPurchaseDate,
        [Description("Data do pedido maior que atual")]
        OrderDateHigherThanCurrent,
        [Description("A lista de produtos deve conter pelo menos um")]
        ProductListMustContainAtLeastOne,
    }


}
