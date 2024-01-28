export async function authenticate(
    email: string,
    password: string
): Promise<string> {
    return email + password;
}
