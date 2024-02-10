using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class WiFiModuleBuilder
{
    public WiFiModuleBuilder()
    {
        WiFiModule = new WiFiModule();
    }

    protected WiFiModule WiFiModule { get; set; }

    public WiFiModuleBuilder SetVersion(string version)
    {
        WiFiModule.Version = version;
        return this;
    }

    public WiFiModuleBuilder SetBluetooth(bool isBluetooth)
    {
        WiFiModule.IsBluetooth = isBluetooth;
        return this;
    }

    public WiFiModuleBuilder SetPciVersion(string version)
    {
        WiFiModule.PciExpressVersion = version;
        return this;
    }

    public WiFiModuleBuilder SetVoltage(double voltage)
    {
        WiFiModule.Voltage = voltage;
        return this;
    }

    public WiFiModule Build()
    {
        if (WiFiModule.Voltage != 0 && WiFiModule.Version is not null && WiFiModule.PciExpressVersion is not null)
        {
            return WiFiModule;
        }

        throw new MissingAttributeException("Attribute from WiFiModule is missing");
    }
}