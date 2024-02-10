using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Types;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IRecipient
{
    public string Id { get; set; }
    public void TakeMessage(Message message);
    public void FilterImportanceLevel(ImportanceLevel importanceLevel);
}