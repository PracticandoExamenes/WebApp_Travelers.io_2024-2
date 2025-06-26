using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using si732pc2u20221f613.API.Subscriptions.domain.model.valueobjects;

namespace si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;

public partial class Plan: IEntityWithCreatedUpdatedDate
{
    public int Id { get; private set; }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 120)
                throw new ArgumentException("Name is required and must be 120 characters or fewer.");
            _name = value;
        }
    }

    private int _maxUsers;
    public int MaxUsers
    {
        get => _maxUsers;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(MaxUsers), "MaxUsers must be greater than zero.");
            _maxUsers = value;
        }
    }

    private int _isDefault;
    public int IsDefault
    {
        get => _isDefault;
        private set
        {
            if (value != 0 && value != 1)
                throw new ArgumentOutOfRangeException(nameof(IsDefault), "IsDefault must be 0 or 1.");
            _isDefault = value;
        }
    }

    private int _monetizationStrategyId;
    public int MonetizationStrategyId
    {
        get => _monetizationStrategyId;
        private set
        {
            if (!Enum.IsDefined(typeof(EMonetizationStrategy), value))
                throw new ArgumentException("Invalid monetization strategy.");
            _monetizationStrategyId = value;
        }
    }
    
    public Plan(string name, int maxUsers, int isDefault, int monetizationStrategyId)
    {
        Name = name;
        MaxUsers = maxUsers;
        IsDefault = isDefault;
        MonetizationStrategyId = monetizationStrategyId;
    }
    
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    
    protected Plan() { }
}