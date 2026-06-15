#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <algorithm>

using namespace std;

// -----------------------------
// Product Structure
// -----------------------------
struct Product {
    int id;
    string name;
    float price;
    int stock;
    vector<int> sales_history;
};

// -----------------------------
// Global Data
// -----------------------------
vector<Product> inventory;
map<string, string> recommendations;

// -----------------------------
// Helper Functions
// -----------------------------
int find_product(string name) {
    for (int i = 0; i < (int)inventory.size(); i++) {
        if (inventory[i].name == name)
            return i;
    }
    return -1;
}
// -----------------------------
// Recommendations
// -----------------------------

string recommend(string product) {
    if (recommendations.count(product))
        return recommendations[product];
    return "No recommendation";
}
// -----------------------------
// predict_sales
// -----------------------------

int predict_sales(Product &p) {
    int n = p.sales_history.size();
    if (n < 2) return 0;
    int slope = p.sales_history[n - 1] - p.sales_history[n - 2];
    int pred = p.sales_history[n - 1] + slope * 2;
    return max(0, pred);
}

// -----------------------------
// Shared View_inventory Function
// -----------------------------
void view_inventory() {
    cout << "\nID\tName\t\tPrice\tStock\n";
    cout << "---------------------------------------------\n";
    for (int i = 0; i < (int)inventory.size(); i++) {
        cout << inventory[i].id << "\t"
             << inventory[i].name << (inventory[i].name.length() < 8 ? "\t\t" : "\t")
             << inventory[i].price << "\t"
             << inventory[i].stock << "\n";
    }
}

// -----------------------------
// ADMIN FUNCTIONS
// -----------------------------
void restock_product() {
    string name;
    int amount;
    cout << "Enter product name to restock: ";
    cin >> ws; getline(cin, name);

// -----------------------------
// for chcking the product in inventory
// -----------------------------
    int idx = find_product(name);
    if (idx == -1) {
        cout << "Product not found!\n";
        return;
    }

    cout << "Current stock: " << inventory[idx].stock << "\nAdd quantity: ";
    cin >> amount;
    inventory[idx].stock += amount;
    cout << "Stock updated successfully!\n";
}

void update_price() {
    string name;
    float price;
    cout << "Enter product name: ";
    cin >> ws; getline(cin, name);

    int idx = find_product(name);
    if (idx == -1) {
        cout << "Product not found!\n";
        return;
    }

    cout << "Current price: " << inventory[idx].price << "\nNew price: ";
    cin >> price;
    inventory[idx].price = price;
    cout << "Price updated successfully!\n";
}

// -----------------------------
// SELL & BILLING
// -----------------------------
void generate_bill(map<string, int> &cart) {
    if (cart.empty()) {
        cout << "Cart empty.\n";
        return;
    }

    float total = 0;
    cout << "\n----- BILL -----\n";

    for (map<string, int>::iterator it = cart.begin(); it != cart.end(); ++it) {
        int idx = find_product(it->first);
        if (idx != -1) {
            float cost = it->second * inventory[idx].price;
            total += cost;
            cout << it->first << " : " << it->second << " x "
                 << inventory[idx].price << " = " << cost << "\n";
        }
    }

    float tax = total * 0.05;
    cout << "Tax (5%): " << tax << "\n";
    cout << "Grand Total: " << total + tax << "\n";
    cout << "---------------\n";
    cart.clear();
}

// -----------------------------
// MENUS
// -----------------------------
void admin_menu() {
    while (true) {
        cout << "\n--- ADMIN MENU ---";
        cout << "\n1-View Inventory\n2-Restock\n3-Update Price\n4-Back\nChoice: ";
        int c; cin >> c;
        if (c == 1) view_inventory();
        else if (c == 2) restock_product();
        else if (c == 3) update_price();
        else if (c == 4) break;
    }
}

void manager_menu() {
    while (true) {
        cout << "\n--- MANAGER ANALYTICS ---";
        cout << "\n1-Inventory\n2-Sales Forecast\n3-Low Stock Alert\n4-Back\nChoice: ";
        int c; cin >> c;
        if (c == 1) view_inventory();
        else if (c == 2) {
            cout << "\n--- SALES FORECAST ---\n";
            for (int i = 0; i < (int)inventory.size(); i++) {
                cout << inventory[i].name << " : " << predict_sales(inventory[i]) << " units predicted\n";
            }
        }
        else if (c == 3) {
    cout << "\n--- LOW STOCK ALERT ---\n";
    bool found = false;
    for (int i = 0; i < (int)inventory.size(); i++) {
        int p = predict_sales(inventory[i]);
        if (inventory[i].stock <= p + 5) {
            cout << "ALERT: Stock of " << inventory[i].name 
                 << " is low! Current stock: " << inventory[i].stock 
                 << ", Predicted need: " << p << "\n";
            found = true;
        }
    }
    if (!found) cout << "All stock levels are sufficient.\n";
}
        else if (c == 4) break;
    }
}

void customer_menu() {
    map<string, int> cart;
    char choice_continue;

    while (true) {
        cout << "\n--- CUSTOMER MENU ---";
        cout << "\n1-Browse Products\n2-Add to Cart\n3-Checkout\nChoice: ";
        int c; cin >> c;

        if (c == 1) {
            for (int i = 0; i < (int)inventory.size(); i++) {
                cout << inventory[i].name << " - Price: " << inventory[i].price << "\n";
            }
        }
        else if (c == 2) {
            string p; int q;
            cout << "Product Name: "; cin >> ws; getline(cin, p);
            cout << "Quantity: "; cin >> q;
            int idx = find_product(p);
            if (idx == -1 || q > inventory[idx].stock) {
                cout << "Not available!\n";
            } else {
                inventory[idx].stock -= q; // Deduct from main stock
                cart[p] += q;
                cout << "Added! AI Recommendation: Buy " << recommend(p) << "\n";
            }
        }
        else if (c == 3) {
            generate_bill(cart);
            
            cout << "\nDo you want to continue shopping? (Y/N): ";
            cin >> choice_continue;

            if (choice_continue == 'n' || choice_continue == 'N') {
                cout << "\n*****************************";
                cout << "\n  THANKS FOR COMING!  ";
                cout << "\n*****************************\n";
                break; 
            }
        }
        else cout << "Invalid choice!\n";
    }
}

// -----------------------------
// INITIAL DATA (10 PRODUCTS)
// -----------------------------
void init_data() {
    Product p;

    p.id = 1; p.name = "Milk"; p.price = 50; p.stock = 25;
    p.sales_history.clear(); p.sales_history.push_back(5); p.sales_history.push_back(8);
    inventory.push_back(p);

    p.id = 2; p.name = "Bread"; p.price = 30; p.stock = 30;
    p.sales_history.clear(); p.sales_history.push_back(8); p.sales_history.push_back(6);
    inventory.push_back(p);

    p.id = 3; p.name = "Eggs"; p.price = 10; p.stock = 50;
    p.sales_history.clear(); p.sales_history.push_back(12); p.sales_history.push_back(15);
    inventory.push_back(p);

    p.id = 4; p.name = "Rice"; p.price = 80; p.stock = 40;
    p.sales_history.clear(); p.sales_history.push_back(4); p.sales_history.push_back(5);
    inventory.push_back(p);

    p.id = 5; p.name = "Oil"; p.price = 200; p.stock = 15;
    p.sales_history.clear(); p.sales_history.push_back(2); p.sales_history.push_back(3);
    inventory.push_back(p);

    p.id = 6; p.name = "Sugar"; p.price = 40; p.stock = 20;
    p.sales_history.clear(); p.sales_history.push_back(7); p.sales_history.push_back(9);
    inventory.push_back(p);

    p.id = 7; p.name = "Tea"; p.price = 120; p.stock = 25;
    p.sales_history.clear(); p.sales_history.push_back(3); p.sales_history.push_back(4);
    inventory.push_back(p);

    p.id = 8; p.name = "Biscuits"; p.price = 25; p.stock = 60;
    p.sales_history.clear(); p.sales_history.push_back(10); p.sales_history.push_back(12);
    inventory.push_back(p);

    p.id = 9; p.name = "Soap"; p.price = 45; p.stock = 35;
    p.sales_history.clear(); p.sales_history.push_back(5); p.sales_history.push_back(5);
    inventory.push_back(p);

    p.id = 10; p.name = "Shampoo"; p.price = 150; p.stock = 10;
    p.sales_history.clear(); p.sales_history.push_back(1); p.sales_history.push_back(2);
    inventory.push_back(p);

    recommendations["Milk"] = "Bread";
    recommendations["Bread"] = "Eggs";
    recommendations["Eggs"] = "Milk";
    recommendations["Rice"] = "Oil";
    recommendations["Oil"] = "Rice";
    recommendations["Sugar"] = "Tea";
    recommendations["Tea"] = "Biscuits";
    recommendations["Biscuits"] = "Tea";
    recommendations["Soap"] = "Shampoo";
    recommendations["Shampoo"] = "Soap";
}

// -----------------------------
// MAIN ENTRY POINT
// -----------------------------
int main() {
    init_data();
    while (true) {
        cout << "\n=== AI STORE MANAGEMENT SYSTEM ===\n";
        cout << "1-Admin\n2-Manager\n3-Customer\n4-Exit\nChoice: ";
        int c; cin >> c;
        if (c == 1) admin_menu();
        else if (c == 2) manager_menu();
        else if (c == 3) customer_menu();
        else if (c == 4) break;
        else cout << "Invalid choice!\n";
    }
    return 0;
}
