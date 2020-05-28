using Abp.Runtime.Validation;
using Service.Demo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Demo.Application.DomainEntities.Member.Dtos
{
    public class GetMemberInput: PagedSortedAndFilteredInputDto, IShouldNormalize
    {



        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {

            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
