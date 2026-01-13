variable "subscription_id" {
    description = "Id de subscripcion de Azure"
    type = string
    default = "f4b8c6e2-1d2a-4c3b-9f5e-123456789abc"
}

variable "location" {
  description = "Región de Azure donde se crearán los recursos"
  type        = string
  default     = "East US 2"
}

variable "environment" {
  description = "Ambiente de la infraestructura (dev, qa, prod)"
  type        = string
  default     = "dev"
}

variable "project_name" {
  description = "Nombre del proyecto para prefijos de recursos"
  type        = string
  default     = "gestion-hotelera"
}