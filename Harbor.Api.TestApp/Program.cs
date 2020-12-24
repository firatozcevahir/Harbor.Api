using Harbor.Api.Models;
using System;
using System.Threading.Tasks;

namespace Harbor.Api.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            HarborClient client = new HarborClient(
                new HarborClientConfiguration(
                    new Uri("https://demo.goharbor.io/"),
                    new Credentials { UserName = "harbortest", Password = "Ab123456" }
                    )
                );

            try
            {
                //var projects = await client.Projects.ListProjects(new ProjectListParameters());
                //var project = await client.Projects.GetProject(projects[1].ProjectId);
                //var projectLogs = await client.Projects.GetProjectLogs(project.Name);

                var products = await client.Products.SearchProductsAsync("test");
                var userRes = await client.Products.SearchUsersByName("harbortest");
                var currUser = await client.Products.GetCurrentUserInfo();

                //await client.Products.CreateLabel(new LabelCreateParameters
                //{
                //    Name= "test-final",
                //    Color = LabelColor.Green,
                //    Description = "Final description",
                //    ProjectId = 4,
                //    Scope = LabelScope.Private
                //});

                // await client.Projects.DeleteProject(4);

                //await client.Projects.CreateProject(new ProjectCreateParameters
                //{
                //    IsPublic = true,
                //    ProjectName = "my-test-project-from-api"
                //});
                //await client.Repositories.DeleteRepository("your-project", "test-image");
                //var user = await client.Products.GetUserById(1); // need admin rights

                //var permissions = await client.Products.GetCurrentUserPermissions($"/project/{project.ProjectId}");
                //var systemInfo = await client.Products.GetSystemInfo();

                //var repositories = await client.Repositories.ListRepositories(project.Name);
                //var repo = await client.Repositories.GetRepository(project.Name, "test-image");

                //var artifacts = await client.Artifacts.ListArtifacts(new ArtifactListParameters
                //{
                //    RepositoryName = "test-image",
                //    ProjectName = project.Name,
                //    WithTag = true,
                //    WithLabel = true,
                //    WithSignature = true,
                //    WithImmutableStatus = true,
                //    WithScanOverview = true
                //});

                //var tags = client.Artifacts.GetTags(new TagListParameters
                //{
                //    ProjectName = project.Name,
                //    Reference = "latest",
                //    RepositoryName = "test-image",
                //    WithSignature = true,
                //    WithImmutableStatus = true
                //});


            }
            catch (HarborApiException ex)
            {
                var res = ex;
            }

            Console.ReadLine();
        }
    }
}
