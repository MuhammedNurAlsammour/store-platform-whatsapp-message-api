const path = require('path');

module.exports = function (plop) {
    const args = process.argv.slice(2);
    let name = '';



    //Angular
    let nameChildirinList = 'list-inventory';
    let nameChildirinCreate = 'create';
    let controllerName = 'InventoryRepairProcess';
    let destPath = 'src/app';



      //Asp
      //By  Id
      //npm run plop-getby -- --name=GetEmployeeByUserId  --path=StorePlatform.Application/Features/Queries
      let application = 'StorePlatform';
      let folder = 'Employee';
      let tableDb = 'Employees';
      let table = 'employee';

      //Asp Controller
      let nameController = 'card'; //{{nameController}}Controller
      let nameCon = 'Personel';



    args.forEach(arg => {
      if (arg.startsWith('--name=')) {
        name = arg.split('=')[1];
      }
      if (arg.startsWith('--path=')) {
          destPath = arg.split('=')[1];
      }
      if (arg.startsWith('--child-name=')) {
          nameChildirinList = arg.split('=')[1];
      }
      if (arg.startsWith('--n-c=')) {
        nameController = arg.split('=')[1];
      }
    });


      const componentName = name.split('-')
      .map(part => part.charAt(0).toUpperCase() + part.slice(1))
      .join('');
      const serviceName = name.split('-')
      .map(part => part.charAt(0).toUpperCase() + part.slice(1))
      .join('');
      const childComponentName = nameChildirinList.split('-')
      .map(part => part.charAt(0).toUpperCase() + part.slice(1))
      .join('');
      const childCreateName = nameChildirinCreate.split('-')
      .map(part => part.charAt(0).toUpperCase() + part.slice(1))
      .join('');
      console.log('Captured name:', name);
      console.log('Destination path:', destPath);
      console.log('Destination path:', componentName);
      console.log('Child component name:', childComponentName);

      plop.setGenerator('component', {
        description: 'Yeni bir Angular bileşeni oluştur',
        prompts: [],
        actions: [
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${name}.component.ts`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/component.ts.hbs'),
                  data: { name ,componentName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${name}.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/component.html.hbs'),
                  data: { name ,componentName,nameChildirinList }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${name}.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/component.scss.hbs'),
                  data: { name ,componentName }
              },
              //list
              {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.ts`),
              templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.ts.hbs'),
              data: { name, componentName, nameChildirinList, childComponentName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.html.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList, controllerName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.scss.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList }
              },
              //Create
              {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${name}/${nameChildirinCreate}/${nameChildirinCreate}.component.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/create/component.ts.hbs'),
                data: { name: nameChildirinCreate, componentName: childCreateName, nameChildirinCreate, childCreateName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinCreate}/${nameChildirinCreate}.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/create/component.html.hbs'),
                  data: { name, componentName, nameChildirinCreate, childCreateName,controllerName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinCreate}/${nameChildirinCreate}.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/create/component.scss.hbs'),
                  data: { name, componentName, nameChildirinCreate , childCreateName}
              },
              // response class
              {
                type: 'add',
                path: path.resolve(__dirname, 'src/app/contracts/responses', `${name}-response.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/contracts/response/response.ts.hbs'),
                data: { name, componentName }
              },
              // request class
              {
                type: 'add',
                path: path.resolve(__dirname, 'src/app/contracts/requests', `request-${name}.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/contracts/request/request.ts.hbs'),
                data: { name, componentName }
              },
              // services
              {
                type: 'add',
                path: path.resolve(__dirname, 'src/app/services/models', `${name}.service.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/service/service.ts.hbs'),
                data: { name, serviceName,controllerName }
              },
              {
                type: 'add',
                path: path.resolve(__dirname, 'src/app/services/models', `${name}.service.spec.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/service/service.spec.ts.hbs'),
                data: { name, serviceName,controllerName }
              }
        ]
      });

     // Generator for Api  component GetAll
     plop.setGenerator('list', {
      description: 'Yeni bir ASP create bileşeni oluştur',
      prompts: [],
      actions: [
            //list
            {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${nameChildirinList}/${nameChildirinList}.component.ts`),
              templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.ts.hbs'),
              data: { name, componentName, nameChildirinList, childComponentName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${nameChildirinList}/${nameChildirinList}.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.html.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList, controllerName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${nameChildirinList}/${nameChildirinList}.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.scss.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList }
              },
      ]
     });







      // Generator for list component
      plop.setGenerator('lc', {
          description: 'Yeni bir Angular list bileşeni oluştur',
          prompts: [],
          actions: [
             {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.ts`),
              templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.ts.hbs'),
              data: { name, componentName, nameChildirinList, childComponentName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.html.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList, controllerName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, destPath, `${name}/${nameChildirinList}/${nameChildirinList}.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/components/List/component.scss.hbs'),
                  data: { name: nameChildirinList, componentName: childComponentName, nameChildirinList }
              }
          ]
      });

      // Generator for list component
      plop.setGenerator('sr', {
          description: 'Yeni bir Angular list bileşeni oluştur',
          prompts: [],
          actions: [
                 // response class
                 {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/contracts/responses', `${name}-response.ts`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/contracts/response/response.ts.hbs'),
                  data: { name, componentName }
                },
                // request class
                {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/contracts/requests', `request-${name}.ts`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/contracts/request/request.ts.hbs'),
                  data: { name, componentName }
                },
                // services
                {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/services/models', `${name}.service.ts`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/service/service.ts.hbs'),
                  data: { name, serviceName,controllerName }
                },
                {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/services/models', `${name}.service.spec.ts`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/service/service.spec.ts.hbs'),
                  data: { name, serviceName,controllerName }
                }
          ]
      });

      // Generator for list component
      plop.setGenerator('di', {
            description: 'Yeni bir Angular list bileşeni oluştur',
            prompts: [],
            actions: [
              {
                type: 'add',
                path: path.resolve(__dirname, 'src/app/dialogs', `${name}/${name}-create-dialog.component.ts`),
                templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/dialogs/component.ts.hbs'),
                data: { name ,componentName }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/dialogs', `${name}/${name}-create-dialog.component.html`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/dialogs/component.html.hbs'),
                  data: { name ,componentName,nameChildirinList }
              },
              {
                  type: 'add',
                  path: path.resolve(__dirname, 'src/app/dialogs', `${name}/${name}-create-dialog.component.scss`),
                  templateFile: path.resolve(__dirname, 'plop-templates/Angular/templates/dialogs/component.scss.hbs'),
                  data: { name ,componentName }
              },
            ]
      });













      // Generator for Api  component controller
      plop.setGenerator('controller', {
      description: 'Yeni bir ASP controller bileşeni oluştur',
      prompts: [],
      actions: [
          {
              type: 'add',
              path: path.resolve(__dirname, `StorePlatform.API/Controllers/${nameController}Controller.cs`),
              templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/controller/controller.hbs'),
              data: { nameCon,nameController,application }
          },
      ]
      });


      // Generator for Api  component GetAll
      plop.setGenerator('getall', {
        description: 'Yeni bir ASP GetAll bileşeni oluştur',
        prompts: [],
        actions: [
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryHandler.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetAll/queryHandler.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryRequest.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetAll/queryRequest.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryResponse.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetAll/queryResponse.hbs'),
                data: { name,folder,application,tableDb,table }
            },
        ]
      });


      // Generator for Api  component GetAll
      plop.setGenerator('getby', {
        description: 'Yeni bir ASP GetById bileşeni oluştur',
        prompts: [],
        actions: [
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryHandler.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetById/queryHandler.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryRequest.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetById/queryRequest.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryResponse.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Queries/GetById/queryResponse.hbs'),
                data: { name,folder,application,tableDb,table }
            },
        ]
      });

      // Generator for Api  component GetAll
      plop.setGenerator('create', {
      description: 'Yeni bir ASP create bileşeni oluştur',
      prompts: [],
      actions: [
          {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryHandler.cs`),
              templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Create/queryHandler.hbs'),
              data: { name,folder,application,tableDb,table }
          },
          {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryRequest.cs`),
              templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Create/queryRequest.hbs'),
              data: { name,folder,application,tableDb,table }
          },
          {
              type: 'add',
              path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryResponse.cs`),
              templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Create/queryResponse.hbs'),
              data: { name,folder,application,tableDb,table }
          },
      ]
      });



      // Generator for Api  component GetAll
      plop.setGenerator('delete', {
        description: 'Yeni bir ASP delete bileşeni oluştur',
        prompts: [],
        actions: [
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryHandler.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Delete/queryHandler.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryRequest.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Delete/queryRequest.hbs'),
                data: { name,folder,application,tableDb,table }
            },
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryResponse.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Delete/queryResponse.hbs'),
                data: { name,folder,application,tableDb,table }
            },
        ]
      });


      // Generator for Api  component GetAll
      plop.setGenerator('update', {
            description: 'Yeni bir ASP update bileşeni oluştur',
            prompts: [],
            actions: [
                {
                    type: 'add',
                    path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryHandler.cs`),
                    templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Update/queryHandler.hbs'),
                    data: { name,folder,application,tableDb,table }
                },
                {
                    type: 'add',
                    path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryRequest.cs`),
                    templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Update/queryRequest.hbs'),
                    data: { name,folder,application,tableDb,table }
                },
                {
                    type: 'add',
                    path: path.resolve(__dirname, destPath, `${folder}/${name}/${name}QueryResponse.cs`),
                    templateFile: path.resolve(__dirname, 'plop-templates/Asp/Features/Commands/Update/queryResponse.hbs'),
                    data: { name,folder,application,tableDb,table }
                },
            ]
      });

};
