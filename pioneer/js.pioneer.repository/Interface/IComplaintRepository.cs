using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> GetAll();
        Task<Complaint> Get(int complaintId);
        Task Create(Complaint model);
        Task<bool> Update(Complaint model);
        Task<DeleteResult> Delete(int complaintId);
    }
}
