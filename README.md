演示地址：http://47.105.135.202:9005  
        测试：admin   admin  
部署环境：linux + mysql + nginx，1M小水管，手下留情    
接口地址：http://47.105.135.202:9004/swagger  

## 使用方法
1. 安装dotnet模板  
        dotnet new -i PSharp.Template  
2. 创建项目  
        dotnet new PSharp.Template --name Company.Project
3. 卸载模板  
        dotnet new -u PSharp.Template  
4. \sample\\*.ApiHost     &emsp;修改数据库链接  
        dotnet run
5. \sample\ui\manage  
        npm install  
        npm run serve  
注：默认mysql数据库，暂不支持动态切换数据库

## 开发环境及依赖库
1. 底层框架
  - [Util](https://github.com/dotnetcore/Util)