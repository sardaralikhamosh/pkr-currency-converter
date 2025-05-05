#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define NUM_CURRENCIES 20

typedef struct {
    char code[4];
    float rate;
} Currency;

void convertFromPKR(float pkrAmount, Currency currencies[], int numCurrencies) {
    printf("\n--- Conversion Results ---\n");
    for (int i = 0; i < numCurrencies; i++) {
        float converted = pkrAmount * currencies[i].rate;
        printf("%.2f PKR = %.2f %s\n", pkrAmount, converted, currencies[i].code);
    }
}

int main() {
    Currency currencies[NUM_CURRENCIES] = {
        {"USD", 0.0036},
        {"EUR", 0.0033},
        {"GBP", 0.0028},
        {"JPY", 0.55},
        {"AUD", 0.0054},
        {"CAD", 0.0049},
        {"CHF", 0.0032},
        {"CNY", 0.026},
        {"INR", 0.30},
        {"SAR", 0.014},
        {"AED", 0.013},
        {"MYR", 0.017},
        {"SGD", 0.0048},
        {"TRY", 0.12},
        {"RUB", 0.33},
        {"BRL", 0.020},
        {"ZAR", 0.066},
        {"KRW", 4.9},
        {"EGP", 0.17},
        {"BDT", 0.40}
    };

    printf("PKR Currency Converter\n");
    printf("=======================\n");

    char input[100];

    while (1) {
        printf("\nEnter amount in Pakistani Rupees (PKR) or type 'exit' to quit: ");
        fgets(input, sizeof(input), stdin);

        // Remove newline character
        input[strcspn(input, "\n")] = 0;

        if (strcasecmp(input, "exit") == 0) {
            break;
        }

        float pkrAmount = atof(input);
        if (pkrAmount == 0 && input[0] != '0') {
            printf("Invalid input. Please enter a valid number.\n");
            continue;
        }

        convertFromPKR(pkrAmount, currencies, NUM_CURRENCIES);
    }

    printf("\nThank you for using PKR Currency Converter!\n");
    return 0;
}
