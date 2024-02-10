export type BudgetPalWebConfig = {
    api: {
        host: string;
        port: {
            http: number;
            https: number;
        };
        https: boolean;
    };
};

export async function getWebConfig(): Promise<BudgetPalWebConfig> {
    const res = await fetch('/webconfig.json');
    const config = await res.json();
    return config as BudgetPalWebConfig;
}
