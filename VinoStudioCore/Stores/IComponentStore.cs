using VinoStudioCore.Components;

namespace VinoStudioCore.Stores
{
    public interface IComponentStore
    {
        public Task<IComponent> AddComponent(IComponent component);
        public Task<IComponent> GetComponent(Guid id);
    }
}
