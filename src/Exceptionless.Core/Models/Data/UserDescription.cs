﻿using Exceptionless.Core.Extensions;

namespace Exceptionless.Core.Models.Data;

public class UserDescription : IData {
    public UserDescription() {
        Data = new DataDictionary();
    }

    public UserDescription(string emailAddress, string description) : this() {
        if (!String.IsNullOrWhiteSpace(emailAddress))
            EmailAddress = emailAddress.Trim();

        if (!String.IsNullOrWhiteSpace(description))
            Description = description.Trim();
    }

    public string EmailAddress { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Extended data entries for this user description.
    /// </summary>
    public DataDictionary Data { get; set; }

    protected bool Equals(UserDescription other) {
        return String.Equals(EmailAddress, other.EmailAddress) && String.Equals(Description, other.Description) && Equals(Data, other.Data);
    }

    public override bool Equals(object obj) {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((UserDescription)obj);
    }

    public override int GetHashCode() {
        unchecked {
            int hashCode = EmailAddress?.GetHashCode() ?? 0;
            hashCode = (hashCode * 397) ^ (Description?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (Data?.GetCollectionHashCode() ?? 0);
            return hashCode;
        }
    }
}
