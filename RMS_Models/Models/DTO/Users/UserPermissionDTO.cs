using RMS_Models.Models.API_Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Users
{
    public class UserPermissionDto
    {

        public int Id { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;
        public string Particulars { get; set; } = string.Empty;
        public bool IsGranted { get; set; }
        public bool IsDenied { get; set; }
        public List<UserPermissionDto> Children { get; set; } = new List<UserPermissionDto>();

        public UserPermissionDto()
        {
        }

        public UserPermissionDto(int id, string moduleName, string divisionName, string particulars, bool isGranted, bool isDenied)
        {
            Id = id;
            ModuleName = moduleName;
            DivisionName = divisionName;
            Particulars = particulars;
            IsGranted = isGranted;
            IsDenied = isDenied;
            Children = new List<UserPermissionDto>();
        }
    }

 

    public class TogglePermissionDTO
    {
        public int PositionId { get; set; }
        public int ParticularId { get; set; }
        public bool IsGranted { get; set; }
    }

    public class PermissionTreeDTO
    {
        public int Id { get; set; }
        public required string ModuleName { get; set; }
        public required string SectionFormControl { get; set; }
        public required string Particulars { get; set; }
        public bool IsGranted { get; set; }
        public bool IsDenied { get; set; }
        public List<PermissionTreeDTO> Children { get; set; } = new List<PermissionTreeDTO>();
    }

    public class PermissionFilterDto
    {
        public string? ModuleName { get; set; }
        public string? SectionName { get; set; }
        public int? PositionId { get; set; }
        public string? SearchText { get; set; }
        public string FilterType { get; set; } = "all";

        public PermissionFilterDto()
        {
        }

        public PermissionFilterDto(string? moduleName, string? sectionName, int? positionId, string? searchText, string filterType = "all")
        {
            ModuleName = moduleName;
            SectionName = sectionName;
            PositionId = positionId;
            SearchText = searchText;
            FilterType = filterType;
        }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(bool success, string? message = null, string? error = null, T? data = default)
        {
            Success = success;
            Message = message;
            Error = error;
            Data = data;
        }
    }

    public class ModuleSectionDto
    {
        public string ModuleName { get; set; } = string.Empty;
        public List<string> Sections { get; set; } = new List<string>();
    }

    public class PermissionSummaryDto
    {
        public int TotalPermissions { get; set; }
        public int GrantedPermissions { get; set; }
        public int DeniedPermissions { get; set; }
        public List<ModuleSectionDto> ModuleSections { get; set; } = new List<ModuleSectionDto>();
    }
}
