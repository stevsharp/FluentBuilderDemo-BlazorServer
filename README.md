# FluentBuilderDemo-BlazorServer

A demo project showing how to implement the **Fluent Builder Pattern** in C# with validation, result handling, and a Blazor Server + MudBlazor front-end.  

This sample extends the *classic* builder approach by:
- ✅ Using a **Result<T>** type instead of exceptions to collect errors  
- ✅ Integrating **FluentValidation** for declarative rules  
- ✅ Adding **Blazor Server UI** with MudBlazor for a clean form experience  
- ✅ Supporting **DTO → Builder** mapping (Mapster/Mapperly example included)  
- ✅ Guarding against invalid state (e.g. negative amounts, past delivery dates, inconsistent currencies)  

---

## 🔧 Technologies & Patterns Used
- **.NET 9** (Blazor Server)
- **MudBlazor** (UI components)
- **Result Pattern** (collect errors instead of throwing exceptions)
- **Mapster** (DTO ↔ domain mapping, with builder integration)

---

