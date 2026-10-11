# SRP, Design Patterns & Inheritance

**Student:** Omar Fathi  
**Program:** Simulation Academy — .NET Diploma  
**Track:** Backend .NET 4

## Project Overview

This project contains my C# implementations and practice for clean code, design patterns, object-oriented programming, and problem solving.

### 1. SRP — Single Responsibility Principle

Refactored classes by separating their responsibilities into smaller, focused classes. Also documented the responsibility of each class to make the code easier to understand and maintain.

### 2. Design Patterns

Implemented and tested three creational design patterns:

- **Singleton:** Created a shared `AppConfig` instance and verified that it is initialized only once.
- **Prototype:** Implemented enemy cloning while ensuring that mutable data, such as weapons and abilities, can be changed independently in the copied object.
- **Builder:** Implemented a `CourseRegistrationBuilder` to construct course registrations with required and optional values while enforcing registration rules.

### 3. Library System — Inheritance & Polymorphism

Designed and implemented a library system using inheritance, encapsulation, and polymorphism.

The implementation includes:

- A class hierarchy for people, staff, members, and library items.
- Different staff roles and monthly pay calculations.
- Different library item types with their own loan periods and late fees.
- Borrowing and returning items with validation.
- Restrictions on student active loans.
- Premium-member late-fee discounts and reading points.
- Protection against invalid operations, such as returning the same loan twice or marking a returned loan as lost.

Also demonstrated polymorphism by processing different staff members and library items through base-class references.

### 4. LeetCode — Problem 1456

Solved **Maximum Number of Vowels in a Substring of Given Length** using the Sliding Window technique to efficiently calculate the maximum number of vowels in a substring of length `k`.

## Repository Structure

- `SRP/` — SRP refactoring and responsibility documentation.
- `DesignPatterns/` — Singleton, Prototype, and Builder implementations.
- `Inheritance/` — Library System class diagram and C# implementation.
- `LeetCode/1456_MaxVowelsInSubstring/` — problem solution and notes.

## Notes

This repository contains my practical work for the assignment, focusing on clean code, object-oriented design, reusable patterns, and efficient problem solving.

Build output folders such as `bin/` and `obj/` should not be committed.