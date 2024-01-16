using System.Collections;

namespace SudokuSolver;

class Set<T> : IEnumerable<T>
{
    private List<T> elements ;

    public Set()
    {
        elements = new List<T>();
    }

    public Set(List<T> elements)
    {
        this.elements = elements;
    }

    public void Add(T element)
    {
        if(!elements.Contains(element))
            elements.Add(element);
    }
    public void Remove(T element)
    {
        elements.Remove(element);
    }

    public bool Contains(T element)
    {
        return elements.Contains(element);
    }

    public Set<T> Intersect(Set<T> other)
    {
        List<T> intersectionElements = new List<T>();
        foreach (var item in this)
        {
            if(other.Contains(item))
                intersectionElements.Add(item);
        }

        return new Set<T>(intersectionElements);
    }
    public Set<T> Union(Set<T> other)
    {
        Set<T> unionElements = new Set<T>();
        
        foreach (T item in this)
        {
            unionElements.Add(item);
        }

        foreach (T item in other)
        {
            unionElements.Add(item);
        }

        return unionElements;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}