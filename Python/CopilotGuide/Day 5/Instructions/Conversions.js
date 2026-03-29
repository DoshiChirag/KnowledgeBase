// Converts between pounds and kilograms
function cv(wt, un) {
  const fc = 0.453592; // pounds → kilograms factor

  if (un === "lb") {
    const kg = wt * fc;
    return { kg };
  }

  if (un === "kg") {
    const lb = wt / fc;
    return { lb };
  }

  throw new Error("Unknown unit");
}

// Example usage:
const rs1 = cv(100, "lb"); // 100 pounds → kg
const rs2 = cv(50, "kg");  // 50 kg → pounds

console.log(rs1);
console.log(rs2);