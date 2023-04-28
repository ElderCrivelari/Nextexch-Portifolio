using System;
using System.Security.Cryptography;
using System.Text;

public static class CryptoUtils
{
    public static string GerarHash(string valor, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(valor, salt, 10000))
        {
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static bool VerificarHash(string valor, string hash)
    {
        byte[] hashBytes = Convert.FromBase64String(hash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        using (var pbkdf2 = new Rfc2898DeriveBytes(valor, salt, 10000))
        {
            byte[] hash2 = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public static byte[] GerarChaveAleatoria(int tamanhoChave)
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] chave = new byte[tamanhoChave];
            rng.GetBytes(chave);
            return chave;
        }
    }

    public static byte[] GerarIvAleatorio(int tamanhoIv)
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] iv = new byte[tamanhoIv];
            rng.GetBytes(iv);
            return iv;
        }
    }

    public static byte[] Criptografar(string valor, byte[] chave, byte[] iv)
    {
        byte[] valorBytes = Encoding.UTF8.GetBytes(valor);
        using (var aes = Aes.Create())
        {
            aes.Key = chave;
            aes.IV = iv;
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(valorBytes, 0, valorBytes.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }
    }

    public static string Descriptografar(byte[] valorCriptografado, byte[] chave, byte[] iv)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = chave;
            aes.IV = iv;
            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                using (var ms = new System.IO.MemoryStream(valorCriptografado))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new System.IO.StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
