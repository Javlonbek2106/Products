using AutoMapper;
using Base64rontTest.Models;
using Base64rontTest.DTOs;
using System;

public class MappingProfile : Profile
{
    private static string path = @"D:\Images\";

    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => MapImageToBase64(src.ImageId))).ReverseMap();

        // If you want to map in the reverse direction as well:
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => MapBase64ToImage(src.ImageId)));
    }

    private string MapImageToBase64(string imageId)
    {
        // Combine the path and imageId to get the full image file path
        string imagePath = path + imageId;

        // Convert the image to base64
        string base64String = ImageToBase64(imagePath+".png");

        // Combine imageId and base64 representation
        return $"{base64String}";
    }

    private string MapBase64ToImage(string imageIdWithBase64)
    {
        if (imageIdWithBase64 != null)
        {
            // Split the combined string into imageId and base64
            string[] parts = imageIdWithBase64.Split('|');

            if (parts.Length == 2)
            {
                // Use only the imageId part when mapping back to Product
                return parts[0];
            }
        }

        return null; // Handle the case when the input is not in the expected format
    }

    public static string ImageToBase64(string imagePath)
    {
        try
        {
            // Read the image file as a byte array
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            // Convert the byte array to a base64-encoded string
            string base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }
}
