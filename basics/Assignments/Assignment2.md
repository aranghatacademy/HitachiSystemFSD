# 📚 Library Management Mini Project – 40-Minute Task

## ⏱ Estimated Duration
**Time Limit:** 40 minutes  
**Level:** Intermediate  
**Concepts Required:** Classes, Interfaces, Enums, Inheritance (C#)

---

## 🧠 Objective

Design a **basic object-oriented model** for an online **Library Management System** that allows **subscribed members** to **rent library items** online.

---

## 📌 Problem Statement

You are tasked with designing a small-scale **Library Management System** for an online platform. The library has various types of **items** such as **Books**, **Magazines**, and **DVDs**. Users can rent these items **only if they have an active subscription**.

Your task is to design the **class hierarchy** and system logic that meets the following requirements using **C# features** like **classes**, **interfaces**, **enums**, and **inheritance**.

---

## 🧩 Functional Requirements

### 1. Library Items

- The system should support different types of items:
  - `Book`
  - `Magazine`
  - `DVD`
- All items must share common properties:
  - Title
  - ID
  - Category
  - Availability
- Implement a base class for common logic and use **inheritance** for specialized items.

---

### 2. Borrowing Behavior

- Only **subscribed members** can borrow items.
- A borrowed item becomes **unavailable** until returned.
- Implement borrowing functionality using an **interface** (`IBorrowable`).

---

### 3. Enums

- Use an **enum** `ItemCategory` to classify items. Example categories:
  - Fiction
  - NonFiction
  - Science
  - History
  - Entertainment

---

### 4. Members

- Members must have:
  - Name
  - Member ID
  - Subscription Status (Active/Inactive)
- Only **active members** can rent items.
- Attempting to borrow with an inactive subscription should throw a meaningful message.

---

### 5. Console Output

The application must demonstrate:
- Creating and listing library items
- Registering members
- Borrowing and returning items
- Handling unauthorized borrow attempts

---

## ✅ Success Criteria

Your solution must:
- Use **inheritance** for item types
- Use **interfaces** for borrowable behavior
- Use **enums** for item categorization
- Contain at least one **runtime interaction** (e.g., simulate borrow/return in `Main()`)

---

## 🚫 Constraints

- No use of databases or file storage
- Keep the logic in-memory
- Avoid UI or web interfaces – console app only

---

## 📌 Deliverables

- A single C# Console Application demonstrating:
  - Defined classes/interfaces/enums
  - Basic logic for renting items
  - Subscription validation
  - Clean and modular code structure

---

