using Api.Ai.Domain.DataTransferObject;
using Api.Ai.Domain.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Interfaces
{
    public interface IEntitiesAppService
    {
        /// <summary>
        /// Retrieves a list of all entities for the agent.
        /// The following request returns all entities for the agent that is associated with the access token.
        /// </summary>
        /// <returns></returns>
        Task<EntitiesResponse> GetAllAsync();

        /// <summary>
        /// Retrieves the specified entity.
        /// The following request returns the entity with ID of {eid}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Entity> GetByIdAsync(string id);

        /// <summary>
        /// Creates a new entity.
        /// The POST body is an entity object without the "id", "isEnum", and "automatedExpansion" elements.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> CreateAsync(Entity entity);

        /// <summary>
        /// Adds entries to the specified entity.
        /// The POST body is an array of entity entry objects in JSON format.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        Task AddEntriesSpecifiedEntityAsync(string id, List<Entry> entries);

        /// <summary>
        /// Creates or updates an array of entities.
        /// The PUT body consists of an array of entity objects without the "id", "isEnum", and "automatedExpansion" elements.
        /// </summary>
        /// <param name="eintities"></param>
        /// <returns></returns>
        Task CreateUpdateAsync(List<Entity> eintities);

        /// <summary>
        /// Updates the specified entity.
        /// The following request updates an entity of ID {eid}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateAsync(string id);

        /// <summary>
        /// Updates entity entries.
        /// he following request updates the {sample} entity entry corresponding to the reference value {sample-value}.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        Task UpdatesEntityEntriesAsync(List<Entry> entries);

        /// <summary>
        /// Deletes the specified entity.
        /// The following request deletes an entity of ID {eid}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteASync(string id);

    }
}
