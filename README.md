# 患者用药管理小程序与后台 API 模板

该仓库提供一套面向微信小程序的 Vue 3 前端示例以及基于 .NET 7 + SQL Server 的后台 API 脚手架，便于快速搭建患者用药管理的原型。

## 前端（微信小程序侧）
- 基于 Vite + Vue 3 + Pinia + Axios。
- 组件：患者列表卡片、用药计划展示、用药计划创建表单。
- 可通过 `VITE_API_URL` 指定后端 API 地址，默认 `http://localhost:5000`。

### 运行
```bash
cd frontend
npm install
npm run dev
```

## 后端（.NET 7 Web API）
- 使用 EF Core SqlServer 访问 SQL Server。
- 提供患者查询、用药计划查询与创建接口。
- 已开启 Swagger，开发模式可通过 `/swagger` 访问。

### 运行
```bash
cd backend/PatientMedication.Api
# 安装依赖并启动
# dotnet restore
# dotnet run
```

### 关键文件
- `Program.cs`：注册控制器、Swagger、CORS、DbContext。
- `Models/*`：患者与用药计划实体。
- `Controllers/PatientsController.cs`：患者列表与按患者查询用药计划。
- `Controllers/SchedulesController.cs`：新增用药计划接口。
- `appsettings.json`：SQL Server 连接字符串示例。

> 注意：默认数据通过 `ApplicationDbContext` 的 `HasData` 提供示例患者与用药计划，生产环境请迁移并使用真实数据库。
