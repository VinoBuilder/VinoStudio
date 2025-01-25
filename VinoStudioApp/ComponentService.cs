using VinoStudioCore.Stores;
using IComponent = VinoStudioCore.Components.IComponent;

namespace VinoStudioApp
{
    public class ComponentService
    {
        private readonly IComponentStore componentStore;

        public ComponentService(IComponentStore componentStore)
        {
            this.componentStore = componentStore;
        }
        
        public async Task<IComponent> AddComponent(IComponent component)
        {
            var c = await componentStore.AddComponent(component);
            return c;
        }
        
        public async Task<IComponent> GetComponent(Guid id)
        {
            var c = await componentStore.GetComponent(id);
            return c;
        }
    }
}
