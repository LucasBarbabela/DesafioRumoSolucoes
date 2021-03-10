using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.DTO;
using Api.Repository.Model;
using Api.Utility;
using FluentAssertions;
using Xunit;
using Api.Enum;

namespace UnitTest
{
    public class FunctionsTest
    {

        [Fact]
        public void Object_NotNull_ReturnFalse()
        {
            CarDTO car = new CarDTO
            {
                Id = 1,
                Brand = "Ferrari",
                Fabrication = "Itália",
                Type = "F50",
                Year = 2002
            };

            Functions.IsAnyNullOrEmpty(car).Should().Be(false);
        }

        [Fact]
        public void Object_Null_ReturnTrue()
        {
            CarDTO car = new CarDTO
            {
                Id = 1,
                Brand = "Ferrari",
                Fabrication = "Itália",
                Type = null,
                Year = 2002
            };

            Functions.IsAnyNullOrEmpty(car).Should().BeTrue();
        }

        [Fact]
        public void ListCarDTO_WithValue_ReturnListInt()
        {
            List<CarDTO> list = new List<CarDTO>();
            list.Add(new CarDTO { Id = 1 });
            list.Add(new CarDTO { Id = 2 });
            list.Add(new CarDTO { Id = 3 });
            List<int> returnList = new List<int> { 1, 2, 3 };

            Functions.IdExtract(list).Should().BeEquivalentTo(returnList);
        }

        [Fact]
        public void ListCarDTO_WithoutValue_ReturnException()
        {
            List<CarDTO> list = new List<CarDTO>();
            Functions.IdExtract(list).Should().BeEmpty();
        }

        [Fact]
        public void CurrentStatus_Progress_ReturnTrue()
        {
            Functions.StatusProgress(ProcessStatusEnum.ConfirmingPayment, ProcessStatusEnum.PaymentApproved)
                .Should().BeTrue();
        }

        [Fact]
        public void CurrentStatus_Cancelled_ReturnTrue()
        {
            Functions.StatusProgress(ProcessStatusEnum.PaymentApproved, ProcessStatusEnum.Cancelled)
                .Should().BeTrue();
        }

        [Fact]
        public void CurrentStatus_Cancelled_ReturnFalse()
        {
            Functions.StatusProgress(ProcessStatusEnum.Delivered, ProcessStatusEnum.Cancelled)
                .Should().BeFalse();
        }

        [Fact]
        public void CurrentStatus_Delivered_ReturnFalse()
        {
            Functions.StatusProgress(ProcessStatusEnum.Cancelled, ProcessStatusEnum.Delivered)
                .Should().BeFalse();
        }


    }
}
