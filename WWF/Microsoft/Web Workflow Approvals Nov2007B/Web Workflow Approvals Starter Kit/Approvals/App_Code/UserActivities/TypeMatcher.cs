using System;

/// <summary>
/// A container for a <see cref="Predicate<>"/> method that matches object instances to their types or base types.
/// </summary>
/// <typeparam name="InstanceType">The type of object instance that will be matched to the list of types.</typeparam>
public class TypeMatcher<InstanceType>
{
    private bool matchDerivedTypes;
    private Type[] typesToMatch;
    private Type lastTypeMatched;

    /// <summary>
    /// Creates a TypeMatcher.
    /// </summary>
    /// <param name="matchDerivedTypes">Indicates whether to match object instances that inherit 
    /// from one of <see cref="typesToMatch"/> as well as concrete instances of those types.</param>
    /// <param name="typesToMatch">The types to match the object instances to. This list will be 
    /// automatically filtered to exclude types that will never match - i.e. types that do not derive from <see cref="InstanceType"/>.</param>
    public TypeMatcher(bool matchDerivedTypes, params Type[] typesToMatch)
    {
        this.typesToMatch = typesToMatch;

        this.matchDerivedTypes = matchDerivedTypes;
    }

    /// <summary>
    /// Matches an instance of <see cref="InstanceType"/> to a list of valid types.
    /// </summary>
    /// <param name="instance">The instance.</param>
    /// <returns>True iff <see cref="instance"/> is an instance of one of <see cref="typesToMatch"/> or,
    /// when <see cref="matchDerivedTypes"/> is true, an instance of a class derived from 
    /// one of the <see cref="typesToMatch"/>.</returns>
    public bool Match(InstanceType matchCandidate)
    {
        Type typeOfMatchCandidate = matchCandidate.GetType();

        return matchDerivedTypes
            ? this.matchTypesDerivedFrom(typeOfMatchCandidate)
            : this.matchTypes(typeOfMatchCandidate);
    }

    private bool matchTypes(Type typeOfMatchCandidate)
    {
        foreach (Type typeToMatch in this.typesToMatch)

            if (typeOfMatchCandidate == typeToMatch)
                return matchFound(typeToMatch);

        return false;
    }

    private bool matchTypesDerivedFrom(Type typeOfMatchCandidate)
    {
        foreach (Type typeToMatch in this.typesToMatch)

            if (typeOfMatchCandidate == typeToMatch || typeOfMatchCandidate.IsSubclassOf(typeToMatch))
                return matchFound(typeToMatch);

        return false;
    }

    /// <summary>
    /// This little method just gathers match hits into a single place so that features like <see cref="LastTypeMatched"/> are easy to support.
    /// </summary>
    private bool matchFound(Type typeThatCandidateMatched)
    {
        lastTypeMatched = typeThatCandidateMatched;
        return true;
    }

    /// <summary>
    /// The last of the possible <see cref="Type"/>s to match to a candidate instance.
    /// </summary>
    public Type LastTypeMatched
    {
        get { return lastTypeMatched; }
    }
}
