using cm.Application.Dtos.professor;
using cm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cm.Application.Contract
{
    public interface IProfessorService
    {
        public Professor CreateProfessor(CreateProfessorDTO createProfessorDTO);
        public Professor UpdateProfessor(UpdateProfessorDTO updateProfessorDTO);
        public Professor GetProfessor(int id);
        public List<Professor> GetProfessors();

    }
}
