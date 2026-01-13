resource "azurerm_resource_group" "resource_group" {
  name = "rg-${var.project_name}-${var.environment}"
  location = var.location
  tags = {
    environment = var.environment
    project     = var.project_name
  }
}