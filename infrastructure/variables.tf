variable "resource_group_name" {
  description = "Name of the resource group"
  type        = string
  default     = "rg-taskmanagement"
}

variable "location" {
  description = "Azure region for resources"
  type        = string
  default     = "West Europe"
}

variable "environment" {
  description = "Environment name"
  type        = string
  default     = "dev"
}

variable "storage_account_name" {
  description = "Name of the storage account"
  type        = string
  default     = "sttaskmanagement"
}

variable "app_service_plan_name" {
  description = "Name of the app service plan"
  type        = string
  default     = "asp-taskmanagement"
}

variable "function_app_name" {
  description = "Name of the function app"
  type        = string
  default     = "func-taskmanagement"
}

variable "app_insights_name" {
  description = "Name of the application insights"
  type        = string
  default     = "ai-taskmanagement"
}
