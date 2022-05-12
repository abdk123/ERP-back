using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Bwire.Authorization
{
    public class BwireAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);


            //Warehouse
            context.CreatePermission(PermissionNames.Page_Warehouse, L("Warehouse"));
            context.CreatePermission(PermissionNames.Action_Warehouse_Create, L("CreateWarehouse"));
            context.CreatePermission(PermissionNames.Action_Warehouse_Update, L("UpdateWarehouse"));
            context.CreatePermission(PermissionNames.Action_Warehouse_Delete, L("DeleteWarehouse"));

            //Place
            context.CreatePermission(PermissionNames.Page_Place, L("Place"));
            context.CreatePermission(PermissionNames.Action_Place_Create, L("CreatePlace"));
            context.CreatePermission(PermissionNames.Action_Place_Update, L("UpdatePlace"));
            context.CreatePermission(PermissionNames.Action_Place_Delete, L("DeletePlace"));

            //WarehouseCategory
            context.CreatePermission(PermissionNames.Page_WarehouseCategory, L("WarehouseCategory"));
            context.CreatePermission(PermissionNames.Action_WarehouseCategory_Create, L("CreateWarehouseCategory"));
            context.CreatePermission(PermissionNames.Action_WarehouseCategory_Update, L("UpdateWarehouseCategory"));
            context.CreatePermission(PermissionNames.Action_WarehouseCategory_Delete, L("DeleteWarehouseCategory"));

            //MaterialRequest
            context.CreatePermission(PermissionNames.Page_MaterialRequest, L("MaterialRequest"));
            context.CreatePermission(PermissionNames.Action_MaterialRequest_Create, L("CreateMaterialRequest"));
            context.CreatePermission(PermissionNames.Action_MaterialRequest_Update, L("UpdateMaterialRequest"));
            context.CreatePermission(PermissionNames.Action_MaterialRequest_Delete, L("DeleteMaterialRequest"));

            //MaterialRequestDetail
            context.CreatePermission(PermissionNames.Page_MaterialRequestDetail, L("MaterialRequestDetail"));
            context.CreatePermission(PermissionNames.Action_MaterialRequestDetail_Create, L("CreateMaterialRequestDetail"));
            context.CreatePermission(PermissionNames.Action_MaterialRequestDetail_Update, L("UpdateMaterialRequestDetail"));
            context.CreatePermission(PermissionNames.Action_MaterialRequestDetail_Delete, L("DeleteMaterialRequestDetail"));

            //Supplier
            context.CreatePermission(PermissionNames.Page_Supplier, L("Supplier"));
            context.CreatePermission(PermissionNames.Action_Supplier_Create, L("CreateSupplier"));
            context.CreatePermission(PermissionNames.Action_Supplier_Update, L("UpdateSupplier"));
            context.CreatePermission(PermissionNames.Action_Supplier_Delete, L("DeleteSupplier"));

            //AttributeValue
            context.CreatePermission(PermissionNames.Page_AttributeValue, L("AttributeValue"));
            context.CreatePermission(PermissionNames.Action_AttributeValue_Create, L("CreateAttributeValue"));
            context.CreatePermission(PermissionNames.Action_AttributeValue_Update, L("UpdateAttributeValue"));
            context.CreatePermission(PermissionNames.Action_AttributeValue_Delete, L("DeleteAttributeValue"));

            //CorrespondingMaterial
            context.CreatePermission(PermissionNames.Page_CorrespondingMaterial, L("CorrespondingMaterial"));
            context.CreatePermission(PermissionNames.Action_CorrespondingMaterial_Create, L("CreateCorrespondingMaterial"));
            context.CreatePermission(PermissionNames.Action_CorrespondingMaterial_Update, L("UpdateCorrespondingMaterial"));
            context.CreatePermission(PermissionNames.Action_CorrespondingMaterial_Delete, L("DeleteCorrespondingMaterial"));

            //Material
            context.CreatePermission(PermissionNames.Page_Material, L("Material"));
            context.CreatePermission(PermissionNames.Action_Material_Create, L("CreateMaterial"));
            context.CreatePermission(PermissionNames.Action_Material_Update, L("UpdateMaterial"));
            context.CreatePermission(PermissionNames.Action_Material_Delete, L("DeleteMaterial"));

            //MaterialPlace
            context.CreatePermission(PermissionNames.Page_MaterialPlace, L("MaterialPlace"));
            context.CreatePermission(PermissionNames.Action_MaterialPlace_Create, L("CreateMaterialPlace"));
            context.CreatePermission(PermissionNames.Action_MaterialPlace_Update, L("UpdateMaterialPlace"));
            context.CreatePermission(PermissionNames.Action_MaterialPlace_Delete, L("DeleteMaterialPlace"));

            //MaterialQuantity
            context.CreatePermission(PermissionNames.Page_MaterialQuantity, L("MaterialQuantity"));
            context.CreatePermission(PermissionNames.Action_MaterialQuantity_Create, L("CreateMaterialQuantity"));
            context.CreatePermission(PermissionNames.Action_MaterialQuantity_Update, L("UpdateMaterialQuantity"));
            context.CreatePermission(PermissionNames.Action_MaterialQuantity_Delete, L("DeleteMaterialQuantity"));

            //MaterialUnit
            context.CreatePermission(PermissionNames.Page_MaterialUnit, L("MaterialUnit"));
            context.CreatePermission(PermissionNames.Action_MaterialUnit_Create, L("CreateMaterialUnit"));
            context.CreatePermission(PermissionNames.Action_MaterialUnit_Update, L("UpdateMaterialUnit"));
            context.CreatePermission(PermissionNames.Action_MaterialUnit_Delete, L("DeleteMaterialUnit"));

            //MaterialAction
            context.CreatePermission(PermissionNames.Page_MaterialAction, L("MaterialAction"));
            context.CreatePermission(PermissionNames.Action_MaterialAction_Create, L("CreateMaterialAction"));
            context.CreatePermission(PermissionNames.Action_MaterialAction_Update, L("UpdateMaterialAction"));
            context.CreatePermission(PermissionNames.Action_MaterialAction_Delete, L("DeleteMaterialAction"));

            //MaterialCategory
            context.CreatePermission(PermissionNames.Page_MaterialCategory, L("MaterialCategory"));
            context.CreatePermission(PermissionNames.Action_MaterialCategory_Create, L("CreateMaterialCategory"));
            context.CreatePermission(PermissionNames.Action_MaterialCategory_Update, L("UpdateMaterialCategory"));
            context.CreatePermission(PermissionNames.Action_MaterialCategory_Delete, L("DeleteMaterialCategory"));

            //Attribute
            context.CreatePermission(PermissionNames.Page_Attribute, L("Attribute"));
            context.CreatePermission(PermissionNames.Action_Attribute_Create, L("CreateAttribute"));
            context.CreatePermission(PermissionNames.Action_Attribute_Update, L("UpdateAttribute"));
            context.CreatePermission(PermissionNames.Action_Attribute_Delete, L("DeleteAttribute"));

            //AttributeOption
            context.CreatePermission(PermissionNames.Page_AttributeOption, L("AttributeOption"));
            context.CreatePermission(PermissionNames.Action_AttributeOption_Create, L("CreateAttributeOption"));
            context.CreatePermission(PermissionNames.Action_AttributeOption_Update, L("UpdateAttributeOption"));
            context.CreatePermission(PermissionNames.Action_AttributeOption_Delete, L("DeleteAttributeOption"));

            //Area
            context.CreatePermission(PermissionNames.Page_Area, L("Area"));
            context.CreatePermission(PermissionNames.Action_Area_Create, L("CreateArea"));
            context.CreatePermission(PermissionNames.Action_Area_Update, L("UpdateArea"));
            context.CreatePermission(PermissionNames.Action_Area_Delete, L("DeleteArea"));

            //City
            context.CreatePermission(PermissionNames.Page_City, L("City"));
            context.CreatePermission(PermissionNames.Action_City_Create, L("CreateCity"));
            context.CreatePermission(PermissionNames.Action_City_Update, L("UpdateCity"));
            context.CreatePermission(PermissionNames.Action_City_Delete, L("DeleteCity"));

            //Manufacturer
            context.CreatePermission(PermissionNames.Page_Manufacturer, L("Manufacturer"));
            context.CreatePermission(PermissionNames.Action_Manufacturer_Create, L("CreateManufacturer"));
            context.CreatePermission(PermissionNames.Action_Manufacturer_Update, L("UpdateManufacturer"));
            context.CreatePermission(PermissionNames.Action_Manufacturer_Delete, L("DeleteManufacturer"));

            //MaterialType
            context.CreatePermission(PermissionNames.Page_MaterialType, L("MaterialType"));
            context.CreatePermission(PermissionNames.Action_MaterialType_Create, L("CreateMaterialType"));
            context.CreatePermission(PermissionNames.Action_MaterialType_Update, L("UpdateMaterialType"));
            context.CreatePermission(PermissionNames.Action_MaterialType_Delete, L("DeleteMaterialType"));

            //Street
            context.CreatePermission(PermissionNames.Page_Street, L("Street"));
            context.CreatePermission(PermissionNames.Action_Street_Create, L("CreateStreet"));
            context.CreatePermission(PermissionNames.Action_Street_Update, L("UpdateStreet"));
            context.CreatePermission(PermissionNames.Action_Street_Delete, L("DeleteStreet"));

            //Unit

            //WarehouseType
            context.CreatePermission(PermissionNames.Page_WarehouseType, L("WarehouseType"));
            context.CreatePermission(PermissionNames.Action_WarehouseType_Create, L("CreateWarehouseType"));
            context.CreatePermission(PermissionNames.Action_WarehouseType_Update, L("UpdateWarehouseType"));
            context.CreatePermission(PermissionNames.Action_WarehouseType_Delete, L("DeleteWarehouseType"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BwireConsts.LocalizationSourceName);
        }
    }
}
