//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;


public class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }

   


    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0; 
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        // typecasting member to be of a Member class
        Member new_member = (Member)member;
        // To be implemented by students in Phase 1
        // check that there is less members then the capacity
        if (!IsFull())
        {
            int pos = count - 1; //initially the value of pos is the index of the last element in the array
            while ((pos >= 0) && (members[pos].CompareTo(new_member) > 0))
            {
                members[pos + 1] = members[pos];
                pos--;
            }
            if(pos >= 0 && members[pos].CompareTo(new_member) == 0)
            {
                return;
            }
            members[pos + 1] = new_member;
            count++;
        }
        else
            Console.WriteLine(new_member + " is not inserted into the sorted list successfully as the sorted list is full!");

    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {
        Member dMember = (Member)aMember;

        int i = 0;
        // getting the position of the deleted member
        while(i < count && (dMember.CompareTo(members[i]) != 0))
        {
            i++;
        }
        if (i != count)
        {
            for (int j = i + 1; j < count; j++)
            {
                members[j - 1] = members[j];
            }
            count--;
        }
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        // typecasting from IMember type to Member type
        Member sMember = (Member)member;

        // initialising binary search parameters
        int l = 0;
        int r = count - 1;

        // performing binary search
        while (l <= r)
        {
            int m = (l + r) / 2;
            // checking if the middle member 
            if (sMember.CompareTo(members[m]) == 0)
            {
                return true;
            }
            else if (sMember.CompareTo(members[m]) < 0)
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        // member not found return false
        return false;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }


}

